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
                            (Name, Date, Id_event_local, Is_active) 
                            VALUES 
                            (@Name, @Date, @Id_event_local, @Is_active);";

                using (var command = new SqliteCommand(sql, connection))
                {
                    if (eventsModel.id_event_local == 0)
                    {
                        command.Parameters.AddWithValue("@Id_event_local", DBNull.Value);
                    }

                    else
                    {
                        command.Parameters.AddWithValue("@Id_event_local", eventsModel.id_event_local);
                    }

                    command.Parameters.AddWithValue("@Name", eventsModel.name);
                    command.Parameters.AddWithValue("@Date", eventsModel.date);
                    command.Parameters.AddWithValue("@Is_active", eventsModel.is_active);
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
                                Date = @Date, 
                                Id_event_local = @id_event_local, 
                                is_active = @is_active
                            WHERE Id = @Id;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    if (eventsModel.id_event_local == 0)
                    {
                        command.Parameters.AddWithValue("@id_event_local", DBNull.Value);
                    }

                    else
                    {
                        command.Parameters.AddWithValue("@id_event_local", eventsModel.id_event_local);
                    }

                    command.Parameters.AddWithValue("@Id", eventsModel.id);
                    command.Parameters.AddWithValue("@Name", eventsModel.name);
                    command.Parameters.AddWithValue("@Date", eventsModel.date);
                    command.Parameters.AddWithValue("@is_active", eventsModel.is_active);
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

        public EventsModel GetEventsById(int id)
        {
            EventsModel eventsModel = new EventsModel();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string sql = @"SELECT id, name, date, is_active, id_event_local 
                           FROM events 
                           WHERE id = @Id;";

                    using (var command = new SqliteCommand(sql, connection))
                    {
                        // Adiciona o parâmetro do ID
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                eventsModel = new EventsModel
                                {
                                    id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    date = reader.GetDateTime(reader.GetOrdinal("date")),
                                    is_active = reader.IsDBNull(reader.GetOrdinal("is_active")) ? false : reader.GetBoolean(reader.GetOrdinal("is_active")),
                                    id_event_local = reader.IsDBNull(reader.GetOrdinal("id_event_local")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_event_local"))
                                };
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Lidar com exceções relacionadas ao banco de dados ou outras
                throw new InvalidOperationException("Erro ao buscar evento no banco de dados.", ex);
            }

            return eventsModel;
        }

    }
} 