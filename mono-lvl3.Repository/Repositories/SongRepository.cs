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
    public class SongRepository : ISongRepository
    {
        #region Properties

        protected IGenericRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        public SongRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Methods

        private IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }

        public virtual async Task<IEnumerable<ISong>> GetAsync(IFilter filter = null)
        {
            try
            {
                if (filter != null)
                {
                    var song = Mapper.Map<IEnumerable<ISong>>(
                        await Repository.GetWhere<Song>()
                        .OrderBy(a => a.Name)
                        .ToListAsync());

                    if (!string.IsNullOrWhiteSpace(filter.SearchString))
                    {
                        song = song.Where(a => a.Name.ToUpper()
                            .Contains(filter.SearchString.ToUpper()));                            
                    }

                    return song;
                }
                else
                {
                    return Mapper.Map<IEnumerable<ISong>>(await Repository.GetWhere<Song>().ToListAsync());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<ISong> GetByIDAsync(Guid id)
        {
            return Mapper.Map<SongDomainModel>(await Repository.GetWhere<Song>().Where(a => a.Id == id).FirstOrDefaultAsync());
        }

        public virtual Task<int> AddAsync(ISong song)
        {
            song.Id = Guid.NewGuid();
            return Repository.AddAsync<Song>(Mapper.Map<Song>(song));
        }

        public virtual Task<int> UpdateAsync(ISong song)
        {
            return Repository.UpdateAsync<Song>(Mapper.Map<Song>(song));
        }

        public virtual async Task<IAlbum> AddArtistsToSongAsync(Guid id, IEnumerable<Guid> artistIds)
        {
            try
            {
                var song = await Repository.GetWhere<Song>().Where(a => a.Id == id).FirstOrDefaultAsync();
                IUnitOfWork unitOfWork = CreateUnitOfWork();

                foreach (Guid artistId in artistIds)
                {
                    var artist = await Repository.GetWhere<Artist>().Where(a => a.Id == artistId).FirstOrDefaultAsync();
                    song.Artists.Add(artist);
                }
                await Repository.UpdateAsync(song);
                song = await Repository.GetByIDAsync<Song>(id);
                return Mapper.Map<AlbumDomainModel>(song);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync<Song>(id);
        }


        // Za popunjavanje dropdown liste za odabir albuma na kojemu se nalazi pjesma
        //public IEnumerable<IAlbum> GetAlbumsAsync()
        //{
        //    var albums = Mapper.Map<IEnumerable<AlbumPOCO>>(Repository.GetWhere<Album>()
        //                                                              .OrderBy(a => a.Name)
        //                                                              .ToList());
        //    return albums;
        //}

        #endregion Methods
    }
}
