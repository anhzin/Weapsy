﻿using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using Weapsy.Domain.EmailAccounts.Commands;
using Weapsy.Domain.EmailAccounts.Events;

namespace Weapsy.Domain.Tests.EmailAccount
{
    [TestFixture]
    public class UpdateEmailAccountDetailsTests
    {
        private UpdateEmailAccountDetails _command;
        private Mock<IValidator<UpdateEmailAccountDetails>> _validatorMock;
        private EmailAccounts.EmailAccount _emailAccount;
        private EmailAccountDetailsUpdated _event;

        [SetUp]
        public void Setup()
        {
            _command = new UpdateEmailAccountDetails
            {
                SiteId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Address = "info@mysite.com",
                DisplayName = "My Site",
                Host = "host",
                Port = 25,
                UserName = "username",
                Password = "password",
                DefaultCredentials = true,
                Ssl = true
            };            
            _validatorMock = new Mock<IValidator<UpdateEmailAccountDetails>>();
            _validatorMock.Setup(x => x.Validate(_command)).Returns(new ValidationResult());
            _emailAccount = new EmailAccounts.EmailAccount();
            _emailAccount.UpdateDetails(_command, _validatorMock.Object);
            _event = _emailAccount.Events.OfType<EmailAccountDetailsUpdated>().SingleOrDefault();
        }

        [Test]
        public void Should_validate_command()
        {
            _validatorMock.Verify(x => x.Validate(_command));
        }

        [Test]
        public void Should_set_address()
        {
            Assert.AreEqual(_command.Address, _emailAccount.Address);
        }

        [Test]
        public void Should_set_display_name()
        {
            Assert.AreEqual(_command.DisplayName, _emailAccount.DisplayName);
        }

        [Test]
        public void Should_set_host()
        {
            Assert.AreEqual(_command.Host, _emailAccount.Host);
        }

        [Test]
        public void Should_set_port()
        {
            Assert.AreEqual(_command.Port, _emailAccount.Port);
        }

        [Test]
        public void Should_set_username()
        {
            Assert.AreEqual(_command.UserName, _emailAccount.UserName);
        }

        [Test]
        public void Should_set_password()
        {
            Assert.AreEqual(_command.Password, _emailAccount.Password);
        }

        [Test]
        public void Should_set_default_credentials()
        {
            Assert.AreEqual(_command.DefaultCredentials, _emailAccount.DefaultCredentials);
        }

        [Test]
        public void Should_set_ssl()
        {
            Assert.AreEqual(_command.Ssl, _emailAccount.Ssl);
        }

        [Test]
        public void Should_add_email_account_details_updated_event()
        {
            Assert.IsNotNull(_event);
        }

        [Test]
        public void Should_set_id_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.Id, _event.AggregateRootId);
        }

        [Test]
        public void Should_set_site_id_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.SiteId, _event.SiteId);
        }

        [Test]
        public void Should_set_address_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.Address, _event.Address);
        }

        [Test]
        public void Should_set_display_name_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.DisplayName, _event.DisplayName);
        }

        [Test]
        public void Should_set_host_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.Host, _event.Host);
        }

        [Test]
        public void Should_set_port_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.Port, _event.Port);
        }

        [Test]
        public void Should_set_username_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.UserName, _event.UserName);
        }

        [Test]
        public void Should_set_password_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.Password, _event.Password);
        }

        [Test]
        public void Should_set_default_credentials_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.DefaultCredentials, _event.DefaultCredentials);
        }

        [Test]
        public void Should_set_ssl_in_email_account_details_updated_event()
        {
            Assert.AreEqual(_emailAccount.Ssl, _event.Ssl);
        }
    }
}
