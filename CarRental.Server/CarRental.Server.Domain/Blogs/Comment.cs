using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Dtos.Comment;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Blogs;

public sealed class Comment : Entity
{
    public Name Name { get; private set; } = default!;
    public Identity BlogId { get; private set; } = default!;
    public Blog? Blog { get; private set; }
    public Description Description { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;

    public void Create(CreateCommentDto dto)
    {
        Name = Name.Create(dto.Name);
        BlogId = new(dto.BlogId);
        Description = Description.Create(dto.Description);
        Email = Email.Create(dto.Email);
    }

    public void Update(UpdateCommentDto dto)
    {
        Id = new(dto.Id);
        Name = Name.Create(dto.Name);
        BlogId = new(dto.BlogId);
        Description = Description.Create(dto.Description);
        Email = Email.Create(dto.Email);
    }

    public void Delete(DeleteCommentDto dto)
    {
        Id = new(dto.Id);
    }

    public List<ListCommentDto> List(List<Comment> comments)
    {
        var dtos = new List<ListCommentDto>();

        foreach (var comment in comments)
        {
            var dto = new ListCommentDto()
            {
                Id = comment.Id.Value,
                Name = comment.Name.Value,
                BlogId = comment.BlogId.Value,
                Description = comment.Description.Value,
                Email = comment.Email.Value
            };

            dtos.Add(dto);
        }

        return dtos;
    }
}
