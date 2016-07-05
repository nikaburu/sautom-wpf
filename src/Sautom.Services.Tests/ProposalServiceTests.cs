using System;
using Moq;
using Sautom.Domain.Entities;
using Sautom.Services.Dto;
using Sautom.Services.Repositories;
using Sautom.Services.UnitOfWork;
using Xunit;

namespace Sautom.Services.Tests
{
	public class ProposalServiceTests
	{
		[Fact]
		public void EditOrAddProposalTestAddProposalCorrectly()
		{
			//Arange
			var unitOfWorkMoq = new Mock<IUnitOfWork>();
			var unitOfWorkFactoryMoq = (new Mock<IUnitOfWorkFactory>());
			unitOfWorkFactoryMoq.Setup(foo => foo.Create()).Returns(unitOfWorkMoq.Object);

			var proposalRepositoryMoq = new Mock<IProposalRepository>();

			ProposalService proposalService = new ProposalService(null, unitOfWorkFactoryMoq.Object, proposalRepositoryMoq.Object, null, null, null, null);

			//Act
			proposalService.EditOrAddProposal(new ProposalEditDto());

			//Assert
			proposalRepositoryMoq.Verify(foo => foo.Add(It.IsAny<Proposal>()), Times.Exactly(1));
			proposalRepositoryMoq.Verify(foo => foo.Update(It.IsAny<Proposal>()), Times.Never());
		}

		[Fact]
		public void EditOrAddProposalTestEditProposalCorrectly()
		{
			//Arange
			var unitOfWorkMoq = new Mock<IUnitOfWork>();
			var unitOfWorkFactoryMoq = (new Mock<IUnitOfWorkFactory>());
			unitOfWorkFactoryMoq.Setup(foo => foo.Create()).Returns(unitOfWorkMoq.Object);

			var data = new ProposalEditDto() { Id = Guid.NewGuid() };

			var proposalRepositoryMoq = new Mock<IProposalRepository>();
			proposalRepositoryMoq.Setup(foo => foo.Get(It.IsAny<Guid>())).Returns(new Proposal() { Id = data.Id });

			ProposalService proposalService = new ProposalService(null, unitOfWorkFactoryMoq.Object, proposalRepositoryMoq.Object, null, null, null, null);

			//Act
			proposalService.EditOrAddProposal(data);

			//Assert
			proposalRepositoryMoq.Verify(foo => foo.Add(It.IsAny<Proposal>()), Times.Never());
			proposalRepositoryMoq.Verify(foo => foo.Update(It.IsAny<Proposal>()), Times.Exactly(1));
		}
	}
}
