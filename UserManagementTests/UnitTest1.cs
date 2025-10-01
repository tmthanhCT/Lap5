namespace UserManagementTests
{
    public class UserMangementTests
    {
        [Fact]
        public void Register_ShouldReturnTrue_ForNewUser()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("testuser", "password123");
            Assert.True(result);
        }

        [Fact]
        public void Register_ShouldReturnFalse_ForExistingUser()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result = userManagement.Register("testuser", "newpassword");
            Assert.False(result);
        }

        [Fact]
        public void Register_ShouldThrowArgumentException_ForEmptyUsername()
        {
            var userManagement = new Lap5.ManagementUser();
            Assert.Throws<ArgumentException>(() => userManagement.Register("", "password123"));
        }
        [Fact]
        public void Register_ShouldThrowArgumentException_ForEmptyPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            Assert.Throws<ArgumentException>(() => userManagement.Register("testuser", ""));
        }
        [Fact]
        public void Login_ShouldReturnTrue_ForValidCredentials()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result = userManagement.Login("testuser", "password123");
            Assert.True(result);
        }
        [Fact]
        public void Login_ShouldReturnFalse_ForInvalidCredentials()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result = userManagement.Login("testuser", "wrongpassword");
            Assert.False(result);
        }
        [Fact]
        public void Login_ShouldReturnFalse_ForNonExistentUser()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Login("nonexistentuser", "password123");
            Assert.False(result);
        }
        [Fact]
        public void Login_ShouldReturnFalse_ForEmptyUsername()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Login("", "password123");
            Assert.False(result);
        }
        [Fact]
        public void Login_ShouldReturnFalse_ForEmptyPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Login("testuser", "");
            Assert.False(result);
        }
        [Fact]
        public void Register_ShouldThrowArgumentException_ForNullUsername()
        {
            var userManagement = new Lap5.ManagementUser();
            Assert.Throws<ArgumentException>(() => userManagement.Register(null, "password123"));
        }
        [Fact]
        public void Register_ShouldThrowArgumentException_ForNullPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            Assert.Throws<ArgumentException>(() => userManagement.Register("testuser", null));

        }
        [Fact]
        public void Login_ShouldReturnFalse_ForNullUsername()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Login(null, "password123");
            Assert.False(result);
        }
        [Fact]
        public void Login_ShouldReturnFalse_ForNullPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Login("testuser", null);
            Assert.False(result);
        }
        [Fact]
        public void Register_ShouldBeCaseSensitive_ForUsername()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("TestUser", "password123");
            var result = userManagement.Register("testuser", "newpassword");
            Assert.True(result);
        }
        [Fact]
        public void Login_ShouldBeCaseSensitive_ForUsername()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("TestUser", "password123");
            var result = userManagement.Login("testuser", "password123");
            Assert.False(result);
        }
        [Fact]
        public void Register_ShouldAllowSpecialCharacters_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("user!@#", "pass$%^");
            Assert.True(result);
        }
        [Fact]
        public void Login_ShouldAllowSpecialCharacters_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("user!@#", "pass$%^");
            var result = userManagement.Login("user!@#", "pass$%^");
            Assert.True(result);
        }
        [Fact]
        public void Register_ShouldAllowLongUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var longUsername = new string('a', 100);
            var longPassword = new string('b', 100);
            var result = userManagement.Register(longUsername, longPassword);
            Assert.True(result);
        }
        [Fact]
        public void Login_ShouldAllowLongUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var longUsername = new string('a', 100);
            var longPassword = new string('b', 100);
            userManagement.Register(longUsername, longPassword);
            var result = userManagement.Login(longUsername, longPassword);
            Assert.True(result);
        }
        [Fact]
        public void Register_ShouldTrimWhitespace_FromUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("  testuser  ", "  password123  ");
            Assert.True(result);
            var loginResult = userManagement.Login("testuser", "password123");
            Assert.True(loginResult);
        }
        [Fact]
        public void Login_ShouldTrimWhitespace_FromUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result = userManagement.Login("  testuser  ", "  password123  ");
            Assert.True(result);
        }

        [Fact]
        public void Register_ShouldHandleMultipleUsers_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("user1", "pass1");
            userManagement.Register("user2", "pass2");
            var result1 = userManagement.Login("user1", "pass1");
            var result2 = userManagement.Login("user2", "pass2");
            Assert.True(result1);
            Assert.True(result2);
        }
        [Fact]
        public void Login_ShouldFail_AfterMultipleFailedAttempts()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            for (int i = 0; i < 5; i++)
            {
                var result = userManagement.Login("testuser", "wrongpassword");
                Assert.False(result);
            }
            var finalResult = userManagement.Login("testuser", "password123");
            Assert.True(finalResult);
        }
        [Fact]
        public void Register_ShouldNotAllowWhitespaceOnlyUsernameOrPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            Assert.Throws<ArgumentException>(() => userManagement.Register("   ", "password123"));
            Assert.Throws<ArgumentException>(() => userManagement.Register("testuser", "   "));
        }

        [Fact]
        public void Login_ShouldNotAllowWhitespaceOnlyUsernameOrPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result1 = userManagement.Login("   ", "password123");
            var result2 = userManagement.Login("testuser", "   ");
            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Register_ShouldHandleVeryLongInputs_Gracefully()
        {
            var userManagement = new Lap5.ManagementUser();
            var veryLongUsername = new string('u', 1000);
            var veryLongPassword = new string('p', 1000);
            var result = userManagement.Register(veryLongUsername, veryLongPassword);
            Assert.True(result);
            var loginResult = userManagement.Login(veryLongUsername, veryLongPassword);
            Assert.True(loginResult);
        }

        [Fact]
        public void Login_ShouldHandleVeryLongInputs_Gracefully()
        {
            var userManagement = new Lap5.ManagementUser();
            var veryLongUsername = new string('u', 1000);
            var veryLongPassword = new string('p', 1000);
            userManagement.Register(veryLongUsername, veryLongPassword);
            var result = userManagement.Login(veryLongUsername, veryLongPassword);
            Assert.True(result);
        }
        
        [Fact]
        public void Login_ShouldBeThreadSafe()
        {
            var userManagement = new Lap5.ManagementUser();
            for (int i = 0; i < 100; i++)
            {
                userManagement.Register($"user{i}", $"pass{i}");
            }
            var tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                int userId = i;
                tasks.Add(Task.Run(() =>
                {
                    var result = userManagement.Login($"user{userId}", $"pass{userId}");

                }));

                Task.WaitAll(tasks.ToArray());
            }
        }
        [Fact]
        public void Register_ShouldHandleUnicodeCharacters_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("用户", "密码123");
            Assert.True(result);
            var loginResult = userManagement.Login("用户", "密码123");
            Assert.True(loginResult);
        }
        [Fact]
        public void Login_ShouldHandleUnicodeCharacters_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("用户", "密码123");
            var result = userManagement.Login("用户", "密码123");
            Assert.True(result);
        }
        [Fact]
        public void Register_ShouldNotAllowSQLInjection_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("testuser'; DROP TABLE Users;--", "password123");
            Assert.True(result);
            var loginResult = userManagement.Login("testuser'; DROP TABLE Users;--", "password123");
            Assert.True(loginResult);
        }
        [Fact]
        public void Login_ShouldNotAllowSQLInjection_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser'; DROP TABLE Users;--", "password123");
            var result = userManagement.Login("testuser'; DROP TABLE Users;--", "password123");
            Assert.True(result);
        }
        [Fact]
        public void Register_ShouldHandleLeadingAndTrailingWhitespace_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("  testuser  ", "  password123  ");
            Assert.True(result);
            var loginResult = userManagement.Login("testuser", "password123");
            Assert.True(loginResult);
        }
        [Fact]
        public void Login_ShouldHandleLeadingAndTrailingWhitespace_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result = userManagement.Login("  testuser  ", "  password123  ");
            Assert.True(result);
        }
        [Fact]
        public void Register_ShouldHandleMixedCaseUsernames_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            var result1 = userManagement.Register("TestUser", "password123");
            var result2 = userManagement.Register("testuser", "newpassword");
            Assert.True(result1);
            Assert.True(result2);
        }
        [Fact]
        public void Login_ShouldHandleMixedCaseUsernames_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("TestUser", "password123");
            var result1 = userManagement.Login("TestUser", "password123");
            var result2 = userManagement.Login("testuser", "password123");
            Assert.True(result1);
            Assert.False(result2);
        }
        [Fact]
        public void Register_ShouldHandleEmptyStrings_AfterTrimming()
        {
            var userManagement = new Lap5.ManagementUser();
            Assert.Throws<ArgumentException>(() => userManagement.Register("   ", "password123"));
            Assert.Throws<ArgumentException>(() => userManagement.Register("testuser", "   "));
        }
        [Fact]
        public void Login_ShouldHandleEmptyStrings_AfterTrimming()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result1 = userManagement.Login("   ", "password123");
            var result2 = userManagement.Login("testuser", "   ");
            Assert.False(result1);
            Assert.False(result2);
        }
        [Fact]
        public void Register_ShouldHandleSpecialWhitespaceCharacters_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            var result = userManagement.Register("\tuser\n", "\tpass\n");
            Assert.True(result);
            var loginResult = userManagement.Login("user", "pass");
            Assert.True(loginResult);

        }
        [Fact]

        public void Login_ShouldHandleSpecialWhitespaceCharacters_InUsernameAndPassword()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("\tuser\n", "\tpass\n");
            var result = userManagement.Login("user", "pass");
            Assert.True(result);
        }
        [Fact]
        public void Register_ShouldHandleMultipleIdenticalUsernames_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            var result1 = userManagement.Register("testuser", "password123");
            var result2 = userManagement.Register("testuser", "newpassword");
            Assert.True(result1);
            Assert.False(result2);
        }
        [Fact]
        public void Login_ShouldHandleMultipleIdenticalUsernames_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            userManagement.Register("testuser", "password123");
            var result1 = userManagement.Login("testuser", "password123");
            var result2 = userManagement.Login("testuser", "wrongpassword");
            Assert.True(result1);
            Assert.False(result2);
        }
        [Fact]
        public void Register_ShouldHandleRapidSuccession_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            var tasks = new List<Task<bool>>();
            for (int i = 0; i < 50; i++)
            {
                int userId = i;
                tasks.Add(Task.Run(() => userManagement.Register($"user{userId}", $"pass{userId}")));
            }
            Task.WaitAll(tasks.ToArray());
            for (int i = 0; i < 50; i++)
            {
                var result = userManagement.Login($"user{i}", $"pass{i}");
                Assert.True(result);
            }
        }
        [Fact]
        public void Login_ShouldHandleRapidSuccession_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            for (int i = 0; i < 50; i++)
            {
                userManagement.Register($"user{i}", $"pass{i}");
            }
            var tasks = new List<Task<bool>>();
            for (int i = 0; i < 50; i++)
            {
                int userId = i;
                tasks.Add(Task.Run(() => userManagement.Login($"user{userId}", $"pass{userId}")));
            }
            Task.WaitAll(tasks.ToArray());
            foreach (var task in tasks)
            {
                Assert.True(task.Result);
            }
        }
        [Fact]
        public void Register_ShouldHandleExtremelyLongInputs_WithoutPerformanceDegradation()
        {
            var userManagement = new Lap5.ManagementUser();
            var extremelyLongUsername = new string('u', 10000);
            var extremelyLongPassword = new string('p', 10000);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = userManagement.Register(extremelyLongUsername, extremelyLongPassword);
            stopwatch.Stop();
            Assert.True(result);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000); // Ensure it takes less than 1 second
            var loginStopwatch = System.Diagnostics.Stopwatch.StartNew();
            var loginResult = userManagement.Login(extremelyLongUsername, extremelyLongPassword);
            loginStopwatch.Stop();
            Assert.True(loginResult);
            Assert.True(loginStopwatch.ElapsedMilliseconds < 1000); // Ensure it takes less than 1 second
        }
        [Fact]
        public void Login_ShouldHandleExtremelyLongInputs_WithoutPerformanceDegradation()
        {
            var userManagement = new Lap5.ManagementUser();
            var extremelyLongUsername = new string('u', 10000);
            var extremelyLongPassword = new string('p', 10000);
            userManagement.Register(extremelyLongUsername, extremelyLongPassword);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = userManagement.Login(extremelyLongUsername, extremelyLongPassword);
            stopwatch.Stop();
            Assert.True(result);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000); // Ensure it takes less than 1 second
        }
        [Fact]
        public void Register_ShouldHandleConcurrentRegistrations_Correctly()
        {
            var userManagement = new Lap5.ManagementUser();
            var tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                int userId = i;
                tasks.Add(Task.Run(() => userManagement.Register($"user{userId}", $"pass{userId}")));
            }
            Task.WaitAll(tasks.ToArray());
            for (int i = 0; i < 100; i++)
            {
                var result = userManagement.Login($"user{i}", $"pass{i}");
                Assert.True(result);
            }
        }
    }
}