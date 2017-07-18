using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using mono_lvl3.Common.Filters;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Model.Common;
using mono_lvl3.Repository.Common;
using AutoMapper;

namespace mono_lvl3.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        #region Properties

        protected IGenericRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        public AlbumRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Methods

        private IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        public virtual async Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null)
        {
            try
            {
                if (filter != null)
                {
                    var albums = Mapper.Map<IEnumerable<IAlbum>>( //IQueryable vs (IEnumerable & List)
                        await Repository.GetWhere<Album>()
                        .OrderBy(a => a.Name)
                        .ToListAsync());

                    if (!string.IsNullOrWhiteSpace(filter.SearchString))
                    {
                        albums = albums.Where(a => a.Name.ToUpper()
                            .Contains(filter.SearchString.ToUpper()));
                    }

                    return albums;
                    //return Mapper.Map<IEnumerable<IAlbum>>(albums);
                }
                else
                {
                    return Mapper.Map<IEnumerable<IAlbum>>(await Repository.GetWhere<Album>().ToListAsync());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IAlbum> GetByIDAsync(Guid id)
        {
            return Mapper.Map<AlbumDomainModel>(await Repository.GetWhere<Album>().Where(a => a.Id == id).FirstOrDefaultAsync());
        }

        public virtual async Task<int> AddAsync(IAlbum album)
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();

            album.Id = Guid.NewGuid();

            await unitOfWork.AddAsync<Album>(Mapper.Map<Album>(album));
            return await unitOfWork.CommitAsync();
        }

        public virtual async Task<int> UpdateAsync(IAlbum album)
        {
            return await Repository.UpdateAsync<Album>(Mapper.Map<Album>(album));
        }

        public virtual async Task<IAlbum> AddArtistsToAlbumAsync(Guid id, IEnumerable<Guid> artistIds)
        {
            try
            {
                var album = await Repository.GetWhere<Album>().Where(a => a.Id == id).FirstOrDefaultAsync();
                IUnitOfWork unitOfWork = CreateUnitOfWork();

                foreach (Guid artistId in artistIds)
                {
                    var artist = await Repository.GetWhere<Artist>().Where(a => a.Id == artistId).FirstOrDefaultAsync();
                    album.Artists.Add(artist);
                }
                await Repository.UpdateAsync(album);
                album = await Repository.GetByIDAsync<Album>(id);
                return Mapper.Map<AlbumDomainModel>(album);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                IUnitOfWork unitOfWork = CreateUnitOfWork();

                await unitOfWork.DeleteAsync<AlbumDomainModel>(id);
                return await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion Methods
    }
}
