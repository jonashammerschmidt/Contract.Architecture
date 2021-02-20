﻿using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.UserManagement.EmailUserPasswordReset
{
    public interface IEmailUserPasswordResetLogic
    {
        ILogicResult InitializePasswordReset(string email, IBrowserInfo browserInfo);

        void RemoveExpiredPasswordResetTokens();

        ILogicResult ResetPassword(string token, string newPassword);
    }
}