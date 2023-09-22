using EduCenter.Desktop.Constants;
using EduCenter.Desktop.Entities.Cources;
using EduCenter.Desktop.Interfaces.Courses;
using EduCenter.Desktop.Utils;
using Microsoft.VisualBasic;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Repositories.Courses;

public class CourseRepository : ICourseRepository
{
    private readonly NpgsqlConnection _connection;
    public CourseRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }

    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Course obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.courses(" +
                "name, image_path, description, intro_video_path, intro_video_thumb, created_at, updated_at) " +
                "VALUES (@name, @image_path, @description, @intro_video_path, @intro_video_thumb, @created_at, @updated_at);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", obj.Name);
                command.Parameters.AddWithValue("image_path", obj.ImagePath);
                command.Parameters.AddWithValue("description", obj.Description);
                command.Parameters.AddWithValue("intro_video_path", obj.IntroVideoPath);
                command.Parameters.AddWithValue("intro_video_thumb", obj.IntroVideoThumb);
                command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IList<Course>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Course>();
            string query = $"select * from courses order by id " +
                $"offset {(@params.PageNumber-1)*@params.PageSize} " +
                $"limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        var course = new Course();
                        course.Id = reader.GetInt64(0);
                        course.Name = reader.GetString(1);
                        course.ImagePath = reader.GetString(2);
                        course.Description = reader.GetString(3);
                        course.IntroVideoPath = reader.GetString(4);
                        course.IntroVideoThumb = reader.GetString(5);
                        course.CreatedAt = reader.GetDateTime(6);
                        course.UpdatedAt = reader.GetDateTime(7);
                        list.Add(course);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Course>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Course> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Course editedObj)
    {
        throw new System.NotImplementedException();
    }
}
