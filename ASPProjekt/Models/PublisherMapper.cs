using BookData.Entities;

namespace ASPProjekt.Models
{
    public class PublisherMapper
    {
        public static PublisherEntity ToEntity(Publisher model)
        {
            return new PublisherEntity()
            {
                Id = model.Id,
                Address = model.Address,
                Books = model.Books,
                Name = model.Name,
                Phone = model.Phone,
            };
        }

        public static Publisher FromEntity(PublisherEntity entity)
        {
            return new Publisher()
            {
                Id = entity.Id,
                Address = entity.Address,
                Books = entity.Books,
                Name = entity.Name,
                Phone = entity.Phone,
            };
        }
    }
}
