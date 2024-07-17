using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.DTOs;
using TopLearn.DataLayer.Entities.User;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services.Interfaces
{
   public interface IUserService
   {
       bool IsExistUserName(string userName);
       bool IsExistEmail(string email);
       int AddUser(User user);
       User LoginUser(LoginViewModel login);
       User GetUserByEmail(string email);
       User GetUserById(int userId);
       User GetUserByActiveCode(string activeCode);
       User GetUserByUserName(string username);
       void UpdateUser(User user);
       bool ActiveAccount(string activeCode);
       int GetUserIdByUserName(string userName);
       void DeleteUser(int userId);

       #region User Panel

       InformationUserViewModel GetUserInformation(string username);
       InformationUserViewModel GetUserInformation(int userId);
       SideBarUserPanelViewModel GetSideBarUserPanelData(string username);
       EditProfileViewModel GetDataForEditProfileUser(string username);
       void EditProfile(string username,EditProfileViewModel profile);
       bool CompareOldPassword(string oldPassword, string username);

       void ChangeUserPassword(string userName, string newPassword);

        #endregion

       #region Wallet

       int BalanceUserWallet(string userName);
       List<WalletViewModel> GetWalletUser(string userName);
       int ChargeWallet(string userName, int amount,string description,bool isPay=false);
       int AddWallet(Wallet wallet);
       Wallet GetWalletByWalletId(int walletId);
       void UpdateWallet(Wallet wallet);

        #endregion

        #region Admin Panel

       UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
       UserForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
       int AddUserFromAdmin(CreateUserViewModel user);
       EditUserViewModel GetUserForShowInEditMode(int userId);
       void EditUserFromAdmin(EditUserViewModel editUser);

       #endregion
   }
}
