using EduCenter.Desktop.Entities.Groups;
using EduCenter.Desktop.Enums;
using EduCenter.Desktop.Interfaces.Groups;
using EduCenter.Desktop.Utils;
using EduCenter.Desktop.ViewModels.Groups;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Repositories.Groups;

public class GroupRepository : BaseRepository, IGroupRepository
{
    public async Task<int> CreateAsync(Group obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.groups(course_id, group_number, type, max_capacity, min_capacity, start_date, end_date, status, description, price_per_month, is_online, created_at, updated_at) " +
                "VALUES (@course_id, @group_number, @type, @max_capacity, @min_capacity, @start_date, @end_date, @status, @description, @price_per_month, @is_online, @created_at, @updated_at);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("course_id", obj.CourseId);
                command.Parameters.AddWithValue("group_number", obj.Number);
                command.Parameters.AddWithValue("type", obj.Type);
                command.Parameters.AddWithValue("max_capacity", obj.MaxCapacity);
                command.Parameters.AddWithValue("min_capacity", obj.MinCapacity);
                command.Parameters.AddWithValue("start_date", obj.StartDate);
                command.Parameters.AddWithValue("end_date", obj.EndDate);
                command.Parameters.AddWithValue("status", obj.Status.ToString());
                command.Parameters.AddWithValue("description", obj.Description);
                command.Parameters.AddWithValue("price_per_month", obj.PricePerMonth);
                command.Parameters.AddWithValue("is_online", obj.IsOnline);
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

    public async Task<IList<GroupViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            List<GroupViewModel> list = new List<GroupViewModel>();
            
            await _connection.OpenAsync();
            string query = $"select * from groups_view order by id offset {@params.SkipCount} limit {@params.PageSize};";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        GroupViewModel groupViewModel = new GroupViewModel()
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            CountStudents = reader.GetInt32(2),
                            MaxCapacity = reader.GetInt16(3),
                            MinCapacity = reader.GetInt16(4),
                            // date affter the brakets
                            // status after the brakets
                            Description = reader.GetString(8),
                            PricePerMonth = reader.GetFloat(9),
                            IsOnline = reader.GetBoolean(10),
                            CreatedAt = reader.GetDateTime(11),
                            UpdatedAt = reader.GetDateTime(12)
                        };
                        groupViewModel.StartDate = reader.GetFieldValue<DateOnly>(5);
                        groupViewModel.EndDate = reader.GetFieldValue<DateOnly>(6);
                        groupViewModel.Status = (GroupStatus) Enum.Parse(typeof(GroupStatus), reader.GetString(7), true);
                        list.Add(groupViewModel);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<GroupViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<GroupViewModel> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> GetLatestGroupNumberByCourseAsync(long courseId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select group_number from groups where course_id={courseId} order by group_number desc limit 1";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return reader.GetInt32(0);
                    }
                    else return 0;
                }
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

    public Task<int> UpdateAsync(long id, Group editedObj)
    {
        throw new System.NotImplementedException();
    }
}
