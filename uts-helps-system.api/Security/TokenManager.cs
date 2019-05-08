using uts_helps_system.api.Data;
using uts_helps_system.api.Security.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using uts_helps_system.api.Models;
using System.Collections;
using System.Collections.Generic;

namespace uts_helps_system.api.Security
{
    public class TokenManager
    {
        private readonly ApplicationDbContext _context;
        public TokenManager(ApplicationDbContext context){
            _context = context;
        }
        public string AssignToken(int userId){
            if(UserExists(userId)) {
                var userTokenCount = GetTokenEntries(userId).Count;
                if(userTokenCount >= 3) {
                    return null; // Only processing 3 tokens per user! No more tokens issued if the user is signed in 3 different times!
                } else {
                    var tokenId = Guid.NewGuid();
                    _context.UserTokenEntryValues.Add(new Models.UserTokenEntry {
                        TokenId = tokenId,
                        UserId = userId
                    });
                    _context.SaveChanges();
                    return tokenId.ToString();
                }
            }
            return null;
        }

        public bool TokenMatches(int userId, string tokenId){
            if(UserExists(userId)){
               return GetTokenEntry(userId, tokenId) != null;
            }
            return false;
        }

        public bool DestroyToken(string tokenId) {
            var userId = GetUserIdByToken(tokenId);
            if(UserExists(userId)) {
                var userTokenEntry = GetTokenEntry(userId, tokenId);
                if(userTokenEntry != null) {
                    _context.UserTokenEntryValues.Remove(userTokenEntry);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DestroyToken(string tokenId, int userId) {
            if(UserExists(userId)) {
                var userTokenEntry = GetTokenEntry(userId, tokenId);
                if(userTokenEntry != null) {
                    _context.UserTokenEntryValues.Remove(userTokenEntry);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool DestroyAllTokens(string tokenId){
            var userId = GetUserIdByToken(tokenId);
            if(UserExists(userId)) {
                var tokenEntries = GetTokenEntries(userId);
                foreach(UserTokenEntry entry in tokenEntries) {
                    _context.UserTokenEntryValues.Remove(entry);
                    _context.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public bool DestroyAllTokens(int userId){
            if(UserExists(userId)) {
                var tokenEntries = GetTokenEntries(userId);
                foreach(UserTokenEntry entry in tokenEntries) {
                    _context.UserTokenEntryValues.Remove(entry);
                    _context.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public int GetUserIdFromToken(string tokenId) {
            return GetUserIdByToken(tokenId);
        }

        public User GetUserModelFromToken(string tokenId) {
            return GetUserFromToken(tokenId);
        }

        private User GetUserFromToken(string tokenId) {
            var userId = GetUserIdByToken(tokenId);
            return _context.UserValues.Where(x => x.UserId == userId).FirstOrDefault<User>();
        }

        private int GetUserIdByToken(string tokenId) {
            try {
                var token = _context.UserTokenEntryValues.Where(x => x.TokenId == new Guid(tokenId)).FirstOrDefault<UserTokenEntry>();
                return (token != null) ? token.UserId : -1;
            } catch(System.FormatException) {
                return -1;
            }
        }

        private bool UserExists(int userId) {
            return _context.UserValues.Where(x => x.UserId == userId).FirstOrDefault<User>() != null;
        }

        private UserTokenEntry GetTokenEntry(int userId, string tokenId){
            try {
                return _context.UserTokenEntryValues.Where(x => x.UserId == userId && x.TokenId == new Guid(tokenId)).FirstOrDefault<UserTokenEntry>();
            } catch(System.FormatException) {
                return null;
            }
        }

        private List<UserTokenEntry> GetTokenEntries(int userId){
            return _context.UserTokenEntryValues.Where(x => x.UserId == userId).ToList();
        }
    }
}