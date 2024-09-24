<template>
    <div class="flex flex-col h-full">
        <!-- make it one component -->
        <form action="" @submit.prevent="addItem">
            <div class="">
                <InputTask :place-holder="'Input Task'" :input-value="inputTask" @input-change="onChangeTask" >
                    <template v-if="errorField!=''" #error>
                        {{ errorField }}
                    </template>
                </InputTask>
                <div class="flex justify-between">
                    <div></div>
                    <SmallButton  :disabled="disabledInput">
                        <p v-if="!createLoading">Add</p>
                        <template v-else>
                            <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-white" />
                        </template>
                    </SmallButton>
                </div>
            </div>
        </form>
        <div class="mt-2 bg-gray-200 rounded-md h-full p-4 transition-all space-y-4  overflow-y-auto">
            <template v-if="tasks != undefined">
                <div v-for="task in tasks" :key="task.taskId">
                    <TaskItem :task="task" @remove-item="removeATask"/>
                </div>
            </template>
            <template v-if="tasks==undefined&&!loading&&error==''">
                <NoItem />
            </template>
            <template v-if="error != ''">
                <ErrorItem>
                    {{ error }}
                </ErrorItem>
            </template>
         
            <template v-if="loading">
                <div class="flex justify-center">
                    <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-gray-400" />
                </div>
            </template>
        </div>
    </div>
</template>
<script setup lang="ts">
import { useTaskList } from '@/composables/tasks/useTaskList';
import type { TaskType } from '@/types/TaskType';
import SkeletonLoading from '../loading/SkeletonLoading.vue';
import SmallButton from './buttons/SmallButton.vue';
import ErrorItem from './ErrorItem.vue';
import InputTask from './InputTask.vue';
import NoItem from './NoItem.vue';
import TaskItem from './TaskItem.vue';
defineProps<{ tasks?: TaskType[], loading: boolean, error: string }>();

const {
    removeATask,
    disabledInput,
    inputTask,
    addItem,
    createLoading,
    errorField,
    onChangeTask,
}= useTaskList();
</script>