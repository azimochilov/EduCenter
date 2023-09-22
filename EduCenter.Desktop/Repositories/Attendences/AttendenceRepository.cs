using EduCenter.Desktop.Entities.Attendences;
using EduCenter.Desktop.Interfaces.Attendences;
using EduCenter.Desktop.Utils;
using EduCenter.Desktop.ViewModels.Attendences;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Repositories.Attendences;

public class AttendenceRepository : BaseRepository, IAttendenceRepository
{
    public Task<int> CreateAsync(Attendence obj)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<AttendenceViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<AttendenceViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<AttendenceViewModel>> GetByDateAsync(long groupId, DateOnly date)
    {
        try
        {
            List<AttendenceViewModel> list = new List<AttendenceViewModel>();

            string query = "select * from attendence_view " +
                "where lesson_date = @lesson_date and group_id = @group_id;";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("lesson_date", date);
                command.Parameters.AddWithValue("group_id", groupId);

                await using (var reader = await command.ExecuteReaderAsync())
                {
                    
                    while(await reader.ReadAsync())
                    {
                        AttendenceViewModel attendenceViewModel = new AttendenceViewModel();
                        attendenceViewModel.Id = reader.GetInt64(0);
                        attendenceViewModel.GroupId = reader.GetInt64(1);
                        attendenceViewModel.GroupName = reader.GetString(2);
                        var fourthcolumn = reader.GetFieldValue<DateTime>(3);
                        attendenceViewModel.LessonDate = DateOnly.FromDateTime(fourthcolumn);
                        attendenceViewModel.StudentFIO = reader.GetString(4);
                        attendenceViewModel.IsAttended = reader.GetBoolean(5);
                        attendenceViewModel.Description = reader.GetString(6);
                        attendenceViewModel.CreatedAt = reader.GetDateTime(7);
                        attendenceViewModel.UpdatedAt = reader.GetDateTime(8);
                        list.Add(attendenceViewModel);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<AttendenceViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long id, Attendence editedObj)
    {
        throw new NotImplementedException();
    }
}
