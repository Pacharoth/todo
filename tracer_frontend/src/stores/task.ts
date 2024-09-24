import { useActionFetchApi } from "@/composables/useApi";
import type { TaskType } from "@/types/TaskType";
import { defineStore } from "pinia";
import { computed, ref, toValue, type Ref } from "vue";
import { PriorityTask, TaskStatus } from "@/enums/TaskEnum";
import { AlertStatus } from "@/enums/AlertEnum";
import { task_message } from "@/contants/response_message";
import { useAlert, useAlertUpdate } from "./alert";
import { useRouter } from 'vue-router'
import { mappingATaskItemFromApis } from "../utils/tasks/mapping";
export const useTaskStore = defineStore("task", () => {
    const { setAlert } = useAlert();
    const alertUpdate = useAlertUpdate();
    const router = useRouter();
    const deleteTask = useActionFetchApi({
        method: "DELETE",
        url: import.meta.env.VITE_BACKENDAPI_TASK

    });
    const updateTask = useActionFetchApi({
        method: "PUT",
        url: import.meta.env.VITE_BACKENDAPI_TASK
    })
    const postTask = useActionFetchApi({
        method: "POST",
        url: import.meta.env.VITE_BACKENDAPI_TASK
    })
    const taskValue:Ref<undefined|TaskType[]> = ref();
    async function removeItem(id: number) {
        await deleteTask.postAPI(null, id.toString());
        taskValue.value = taskValue.value?.filter((item: any) => item['taskId'] != id);
        setAlert(AlertStatus.SUCCESS, task_message.deleteSuccess);
    }
    function setTasks(data: any) {
        taskValue.value = data
    }
    async function updateItem(task: TaskType, status?: boolean) {
        let findIndexItem = taskValue.value!.findIndex((item: TaskType) => item.taskId == task.taskId);
        await updateTask.postAPI(JSON.stringify(task), `${task.taskId}`, true);
            taskValue.value![findIndexItem] = mappingATaskItemFromApis(updateTask.data.value.data);
        if (status) {
            setAlert(AlertStatus.SUCCESS, task_message.updateSuccess);
            return;
        }
        alertUpdate.setAlert(AlertStatus.SUCCESS, task_message.updateSuccess);

    }
    async function addItem(title: string) {
        let newTask: TaskType = {
            title,
            description: "",
            priorityStatus: PriorityTask.LOW,
            taskStatus: TaskStatus.UNCOMPLETE,
        }
        await postTask.postAPI(JSON.stringify(newTask), "", true);
        let value = toValue(postTask.data);
        taskValue.value = [mappingATaskItemFromApis(value.data), ...taskValue.value!,]
        setAlert(AlertStatus.SUCCESS, task_message.createSuccess);

    }
    function routeToUpdateTask(id: number) {
        router.push(`/${id}`)
    }
    const tasks = computed(() => taskValue);
    const deleteLoading = computed(() => deleteTask.loading);
    const updateStatusLoading = computed(() => updateTask.loading);
    const createLoading = computed(() => postTask.loading);
    const errorDelete = computed(() => deleteTask.error);
    const createError = computed(() => postTask.error);
    return {
        tasks,
        errorDelete,
        setTasks,
        createError,
        removeItem,
        deleteLoading,
        addItem,
        createLoading: createLoading,
        updateItem,
        updateLoading: updateStatusLoading,
        routeToUpdateTask,
    }
});