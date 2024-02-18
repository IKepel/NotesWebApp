using Contracts;
using DAL;
using Moq;

namespace NotesProcessor.Tests
{
    public class NotesProcessorTests
    {
        [Fact]
        public void GetAllNotes_Returns_AllNotes()
        {
            // Arrange
            var mockRepository = new Mock<INoteRepository>();
            var notesConverter = new NotesConverter(mockRepository.Object);

            var expectedNotes = new List<Note>
            {
                new Note { Id = Guid.NewGuid(), Name = "jiojergerg", Value = "4905", Priority = 2 },
                new Note { Id = Guid.NewGuid(), Name = "fmeiorjg", Value = "5332", Priority = 4 },
                new Note { Id = Guid.NewGuid(), Name = "fjioerjh", Value = "4211", Priority = 3 },
            };

            mockRepository.Setup(repo => repo.GetAllNotes()).Returns(expectedNotes);

            // Act
            var result = notesConverter.GetAllNotes();

            // Assert
            Assert.Equal(expectedNotes, result);
        }

        [Fact]
        public void GetAllNotes_Returns_EmptyList_When_RepositoryIsEmpty()
        {
            // Arrange
            var mockRepository = new Mock<INoteRepository>();
            var notesConverter = new NotesConverter(mockRepository.Object);

            mockRepository.Setup(repo => repo.GetAllNotes()).Returns(new List<Note>());

            // Act
            var result = notesConverter.GetAllNotes();

            // Assert
            Assert.Empty(result);
        }
    }
}