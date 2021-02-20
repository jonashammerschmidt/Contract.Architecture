using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Modules.SessionManagement.Sessions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.SessionManagement.Sessions
{
    [TestClass]
    public class SessionsRepositoryTests
    {
        [TestMethod]
        public void CreateSessionAndGetSessionTest()
        {
            // Arrange
            SessionsRepository sessionsRepository = new InMemoryRepositories().GetSessionsRepository();
            IDbSession sessionToAdd = DbSessionMocking.Create();

            // Act
            sessionsRepository.CreateSession(sessionToAdd);
            IDbSession session = sessionsRepository.GetSession(sessionToAdd.Token);

            // Assert
            Assert.AreEqual(sessionToAdd.Token, session.Token);
            Assert.AreEqual(sessionToAdd.ExpiresOn, session.ExpiresOn);
            Assert.AreEqual(sessionToAdd.EmailUserId, session.EmailUserId);
        }

        [TestMethod]
        public void DeleteExpiredSessionsTest()
        {
            // Arrange
            Guid emailUserId = Guid.NewGuid();
            SessionsRepository sessionsRepository = new InMemoryRepositories().GetSessionsRepository();
            IDbSession sessionToAdd = DbSessionMocking.CreateForEmailUser(emailUserId, Guid.NewGuid().ToString());
            sessionToAdd.ExpiresOn = DateTime.Now.AddMinutes(-30);
            sessionsRepository.CreateSession(sessionToAdd);

            // Act
            sessionsRepository.DeleteExpiredSessions(DateTime.Now);

            // Assert
            List<IDbSession> sessions = sessionsRepository.GetSessionsOfEmailUser(emailUserId).ToList();
            Assert.AreEqual(0, sessions.Count);
        }

        [TestMethod]
        public void DeleteSessionsOfEmailUserTest()
        {
            // Arrange
            Guid emailUserId = Guid.NewGuid();
            SessionsRepository sessionsRepository = new InMemoryRepositories().GetSessionsRepository();
            IDbSession sessionToAdd = DbSessionMocking.CreateForEmailUser(emailUserId, Guid.NewGuid().ToString());
            sessionsRepository.CreateSession(sessionToAdd);

            // Act
            sessionsRepository.DeleteSessionsOfEmailUser(emailUserId);

            // Assert
            List<IDbSession> sessions = sessionsRepository.GetSessionsOfEmailUser(emailUserId).ToList();
            Assert.AreEqual(0, sessions.Count);
        }

        [TestMethod]
        public void DeleteSessionTest()
        {
            // Arrange
            SessionsRepository sessionsRepository = new InMemoryRepositories().GetSessionsRepository();
            IDbSession sessionToAdd = DbSessionMocking.Create();
            sessionsRepository.CreateSession(sessionToAdd);

            // Act
            sessionsRepository.DeleteSession(sessionToAdd.Token);

            // Assert
            IDbSession session = sessionsRepository.GetSession(sessionToAdd.Token);
            Assert.IsNull(session);
        }

        [TestMethod]
        public void GetSessionsOfEmailUserTest()
        {
            // Arrange
            Guid emailUserId = Guid.NewGuid();
            SessionsRepository sessionsRepository = new InMemoryRepositories().GetSessionsRepository();
            IDbSession sessionToAdd = DbSessionMocking.CreateForEmailUser(emailUserId, Guid.NewGuid().ToString());
            sessionsRepository.CreateSession(sessionToAdd);

            // Act
            List<IDbSession> sessions = sessionsRepository.GetSessionsOfEmailUser(emailUserId).ToList();

            // Assert
            Assert.AreEqual(sessionToAdd.Token, sessions[0].Token);
            Assert.AreEqual(sessionToAdd.ExpiresOn, sessions[0].ExpiresOn);
            Assert.AreEqual(sessionToAdd.EmailUserId, sessions[0].EmailUserId);
        }
    }
}