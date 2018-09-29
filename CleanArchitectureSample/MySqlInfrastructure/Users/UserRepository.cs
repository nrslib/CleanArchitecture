using System.Collections.Generic;
using Domain.Domain.Users;
using MySql.Data.MySqlClient;

namespace MySqlInfrastructure.Users
{
    public class UserRepository : IUserRepository {
        public void Save(User user) {
            using (var con = new MySqlConnection(Config.ConnectionString)) {
                con.Open();

                bool isExist;
                using (var com = con.CreateCommand()) {
                    com.CommandText = "SELECT * FROM t_user WHERE id = @id";
                    com.Parameters.Add(new MySqlParameter("@id", user.Id));
                    var reader = com.ExecuteReader();
                    isExist = reader.Read();
                }

                using (var command = con.CreateCommand()) {
                    command.CommandText = isExist
                        ? "UPDATE t_user SET username = @username WHERE id = @id"
                        : "INSERT INTO t_user VALUES(@id, @username)";
                    command.Parameters.Add(new MySqlParameter("@id", user.Id));
                    command.Parameters.Add(new MySqlParameter("@username", user.UserName));
                    command.ExecuteNonQuery();
                }
            }
        }

        public User FindByUserName(string username) {
            using (var con = new MySqlConnection(Config.ConnectionString)) {
                con.Open();
                using (var com = con.CreateCommand()) {
                    com.CommandText = "SELECT * FROM t_user WHERE username = @username";
                    com.Parameters.Add(new MySqlParameter("@username", username));
                    var reader = com.ExecuteReader();
                    if (reader.Read()) {
                        var id = reader["id"] as string;

                        return new User(
                            id,
                            username
                        );
                    } else {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<User> FindAll() {
            using (var con = new MySqlConnection(Config.ConnectionString)) {
                con.Open();
                using (var com = con.CreateCommand()) {
                    com.CommandText = "SELECT * FROM t_user";
                    var reader = com.ExecuteReader();
                    var results = new List<User>();
                    while (reader.Read()) {
                        var id = reader["id"] as string;
                        var username = reader["username"] as string;
                        var user = new User(
                            id,
                            username
                        );
                        results.Add(user);
                    }
                    return results;
                }
            }
        }
    }
}
