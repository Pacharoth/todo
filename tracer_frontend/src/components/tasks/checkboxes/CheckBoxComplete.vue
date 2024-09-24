<template>
    <CheckBoxItem @update="updateStatus(!(task.taskStatus == TaskStatus.COMPLETE))" className="
                             group text-white bg-lime-700 p-2 hover:bg-lime-600  ">
                             <template v-if="loading">
            <SkeletonLoading className="h-5 w-5 [&>*]:w-20 text-white [&>*]:bg-white" />
        </template>
        <template v-else>
            <div class="hidden group-hover:block group-hover:animate-fade p-[2px] border-white rounded-md border-2">
            <IconCheck className=" w-3 h-3" :stroke-width="3" />
        </div>
        </template>
                           
        <IconClock className="w-5 h-5 group-hover:hidden group-hover :animate-fade " :stroke-width="2" />
        <p>{{ task?.dueTo ? moment(task.dueTo).format('LL') : '' }}</p>
    </CheckBoxItem>
</template>
<script setup lang="ts">
import SkeletonLoading from '@/components/loading/SkeletonLoading.vue';

import moment from 'moment';
import CheckBoxItem from './CheckBoxItem.vue';
import type { TaskType } from '@/types/TaskType';
import IconCheck from '../../icons/IconCheck.vue';
import IconClock from '../../icons/IconClock.vue';

import { TaskStatus } from '@/enums/TaskEnum';
const emit = defineEmits(['update'])
function updateStatus(status: boolean) {
    emit("update", status)
}
defineProps<{ task: TaskType,loading:boolean, }>();
</script>