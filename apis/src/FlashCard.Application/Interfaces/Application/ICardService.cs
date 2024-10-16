using FlashCard.Application.Models;

namespace FlashCard.Application.Interfaces.Application;

public interface ICardService
{
    Task<SearchCardResponse> SearchAsync(SearchCardRequest request, CancellationToken cancellationToken = default);
    Task<CardDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> CreateAsync(CreateCardRequest request, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, UpdateCardRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<string> GenerateDescriptionByTitleAsync(string title);
}
