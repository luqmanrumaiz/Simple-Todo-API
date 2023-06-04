﻿using Backend.Models;
using ErrorOr;

namespace Backend.Services;

    public interface ITodoTaskService
    {
        ErrorOr<Created> AddTask(TodoTask todoTask);
        ErrorOr<TodoTask> GetTask(Guid id);
    }
