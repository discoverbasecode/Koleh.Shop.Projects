using Ardalis.Result;
using Framework.Application.MediatR.Command.Interfaces;
using Framework.Domain.Entities;

namespace SM.Application.Contracts.Features.Category;

public record AddCategoryChildCommand(
    Guid ParentId,
    string Title,
    string Slug,
    ISeoInfo SeoInfo) : IBaseCommand;