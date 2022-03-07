using MediatR;
using UniAdmin.Contracts.Data;
using UniAdmin.Contracts.DTO;
using UniAdmin.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using UniAdmin.Core.Exceptions;

namespace UniAdmin.Providers.Handlers.Commands
{
    public class CreateDealCommand : IRequest<int>
    {
        public CreateDealDTO Model { get; }
        public CreateDealCommand(CreateDealDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateDealCommandHandler : IRequestHandler<CreateDealCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateDealDTO> _validator;

        public CreateDealCommandHandler(IUnitOfWork repository, IValidator<CreateDealDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            CreateDealDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Deal
            {
                Name = model.Name,
                Amount = model.Amount,
            };

            _repository.Deals.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}