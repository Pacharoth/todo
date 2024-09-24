import { PriorityTask, PriorityTaskConstant, TaskStatus, TaskStatusConstant } from "@/enums/TaskEnum";
import type { TaskType } from "@/types/TaskType";
// use to serialize or mapping to the TaskType
export function mappingATaskItemFromApis(data: any): TaskType {
    let dataSerialized: TaskType = {
        ...data,
        taskStatus: mappingTaskStatus(data.taskStatus),
        priorityStatus: mappingTaskPriorityStatus(data.priorityStatus),
        updatedAt:data.updatedAt?new Date(data.updatedAt):undefined,
        dueTo:data.dueTo? new Date(data.dueTo):undefined,
    }
    return dataSerialized;
}
// use to mapping string to enum task status
function mappingTaskStatus(data: string): TaskStatus {
    if (data == TaskStatusConstant.COMPLETE) return TaskStatus.COMPLETE;
    return TaskStatus.UNCOMPLETE;
}
// use to mapping string to enum priority task
function mappingTaskPriorityStatus(data: string): PriorityTask {
    if (data == PriorityTaskConstant.HIGH) return PriorityTask.HIGH;
    else if (data == PriorityTaskConstant.LOW) return PriorityTask.LOW;
    return PriorityTask.MEDIUM;
}
// use to mapping api from tasks
export function mappingTaskItemListFromApis(data: []): TaskType[] {
    const tasks = [];
    for (const taskItem of data) {
        tasks.push(mappingATaskItemFromApis(taskItem));
    }
    return tasks;
}