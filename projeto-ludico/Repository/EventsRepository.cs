using System;
using System.Data;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

namespace projeto_ludico.Repository
{
    public class EventsRepository
    {
        public void AddEvent(EventsModel eventsModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = @"INSERT INTO events 
                            (Name, Description, Date, Id_Local, Status, Created_At) 
                            VALUES 
                            (@Name, @Description, @Date, @Id_Local, @Status, @Created_At);";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", eventsModel.name);
                    command.Parameters.AddWithValue("@Description", eventsModel.description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Date", eventsModel.date);
                    command.Parameters.AddWithValue("@Id_Local", eventsModel.id_local);
                    command.Parameters.AddWithValue("@Status", eventsModel.status);
                    command.Parameters.AddWithValue("@Created_At", eventsModel.created_at);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEvent(EventsModel eventsModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = @"UPDATE events 
                            SET Name = @Name, 
                                Description = @Description, 
                                Date = @Date, 
                                Id_Local = @Id_Local, 
                                Status = @Status, 
                                Updated_At = @Updated_At 
                            WHERE Id = @Id;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", eventsModel.id);
                    command.Parameters.AddWithValue("@Name", eventsModel.name);
                    command.Parameters.AddWithValue("@Description", eventsModel.description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Date", eventsModel.date);
                    command.Parameters.AddWithValue("@Id_Local", eventsModel.id_local);
                    command.Parameters.AddWithValue("@Status", eventsModel.status);
                    command.Parameters.AddWithValue("@Updated_At", eventsModel.updated_at);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEvent(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM events WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new InvalidOperationException("Evento não encontrado.");
                }
            }
        }

        public DataTable GetAllEvents()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = @"SELECT e.*, l.Name as Local_Name 
                            FROM events e 
                            LEFT JOIN events_local l ON e.Id_Local = l.Id 
                            ORDER BY e.Date DESC;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    using (var adapter = new SqliteDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        public DataTable SearchEvents(string searchTerm)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = @"SELECT e.*, l.Name as Local_Name 
                            FROM events e 
                            LEFT JOIN events_local l ON e.Id_Local = l.Id 
                            WHERE e.Name LIKE @SearchTerm 
                               OR e.Description LIKE @SearchTerm 
                            ORDER BY e.Date DESC;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                    using (var adapter = new SqliteDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        public EventsModel GetEventById(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "SELECT * FROM events WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EventsModel
                            {
                                id = reader.GetInt32(reader.GetOrdinal("Id")),
                                name = reader.GetString(reader.GetOrdinal("Name")),
                                description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                id_local = reader.GetInt32(reader.GetOrdinal("Id_Local")),
                                status = reader.GetString(reader.GetOrdinal("Status")),
                                created_at = reader.GetDateTime(reader.GetOrdinal("Created_At")),
                                updated_at = reader.IsDBNull(reader.GetOrdinal("Updated_At")) ? null : (DateTime?)reader.GetDateTime(reader.GetOrdinal("Updated_At"))
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
} 