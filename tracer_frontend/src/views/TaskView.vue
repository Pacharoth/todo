<template>
    <div class=" relative  max-w-screen-sm w-full 
     rounded-xl h-full max-h-[700px] p-4 space-y-5 flex-col flex">
        <h1 class="font-semibold text-slate-700  text-4xl text-center">Task Management</h1>
        <div class="relative w-full h-full p-4 bg-gray-50 rounded-xl shadow-md">
            <TaskList :tasks="tasks" :loading="loading" :error="error" />
        </div>
    </div>
</template>
<script setup lang="ts">
import TaskList from '@/components/tasks/TaskList.vue';
import { useFetchApi } from '@/composables/useApi';
import { useTaskStore } from '@/stores/task';
import { taskApi } from '@/utils/apis';
import { mappingTaskItemListFromApis } from '@/utils/tasks/mapping';

import {  watch } from 'vue';
const urlTask = `${import.meta.env.VITE_BACKENDAPI_TASK}`;
const { data, loading, error } = useFetchApi(urlTask);
const { tasks, setTasks } = useTaskStore();
watch(data, (value) => {
    setTasks(mappingTaskItemListFromApis(value?.data));
})
</script>