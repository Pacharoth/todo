import type { PriorityTask, TaskStatus } from "@/enums/TaskEnum";

export type TaskType = {
    taskId?: number,
    title: string,
    description?: string,
    updatedAt?: Date,
    createdAt?: Date,
    dueTo?: Date,
    taskStatus: TaskStatus,
    priorityStatus: PriorityTask,
}