<template>
    <div class="relative animate-fade transition-all">
        <template v-if="task.taskStatus==TaskStatus.COMPLETE">
            <StatusPriorityItem className="  bg-lime-700 animate-fade" />

        </template>
        <!-- check priority -->
        <template v-else-if="task.priorityStatus == PriorityTask.HIGH">
            <StatusPriorityItem className=" bg-rose-400 animate-fade" />
        </template>
        <template v-else-if="task.priorityStatus == PriorityTask.MEDIUM">
            <StatusPriorityItem className=" bg-amber-400 animate-fade" />
        </template>
        <template v-else-if="task.priorityStatus == PriorityTask.LOW">
            <StatusPriorityItem className=" bg-slate-500 animate-fade" />
        </template>
        <div class="
     transition-all hover:scale-100
     peer 
     hover:shadow-md
    bg-white px-4 py-2 rounded-b-md 
    cursor-pointer" @mouseover="mouseOverItem" 
    @dblclick="routeTo"
    @mouseleave="mouseLeaveItem">

            <div class="flex justify-between 
    items-center
    ">
                <div class="flex flex-col max-w-sm">
                    <h1 class="line-clamp-1 font-semibold text-slate-600 font-sans text-lg">
                        {{ task.title }}
                    </h1>
                    <div class="flex space-x-2 items-center">
                        <template v-if="task.taskStatus == TaskStatus.COMPLETE && task.dueTo">
                           <CheckBoxComplete @update="updateStatus" :task="task" :loading="updateLoading"/>
                        </template>
                        <template v-else-if="dayDiff">
                            <template v-if=" dayDiff < 3">
                                <CheckBoxUncomplete @update="updateStatus"  className="bg-rose-500 p-2 hover:bg-rose-400" :loading="updateLoading" :task="task"/>
                            </template>
                            <template v-else-if="dayDiff < 5">
                                <CheckBoxUncomplete @update="updateStatus" className="bg-amber-500 p-2 hover:bg-amber-400" :loading="updateLoading" :task="task"/>
                            </template>
                            <template v-else-if="dayDiff >5">
                                <CheckBoxUncomplete @update="updateStatus" 
                                className="bg-slate-500 p-2 hover:bg-slate-400"
                                 :loading="updateLoading" :task="task"/>
                            </template>
                        </template>
                        <pre
                            class="  line-clamp-1  font-sans whitespace-pre-line text-gray-500  max-w-60">{{ task.description }} </pre>
                    </div>
                </div>
                <div>
                    <template v-if="hoverItem">
                        <CircleButton :disabled="false" @click="removeItem">
                            <template v-if="!loadingDelete">
                                <IconXMark className="w-5 h-5" :strokeWidth="2" />
                            </template>
                            <template v-else>
                                <SkeletonLoading className="h-5 w-5 [&>*]:w-20 [&>*]:bg-gray-400" />
                            </template>
                        </CircleButton>
                    </template>
                </div>
            </div>
        </div>
        <div class="absolute peer-hover:block left-1/2 transform z-10 
        -translate-x-2/4 mt-2 hidden
         transition-all ease-in-out delay-150 animate-fade  bg-slate-600 text-white text-sm px-2 py-1 rounded">
            Double Click to edit
        </div>
    </div>
</template>
<script setup lang="ts">
import { useTaskItem } from '@/composables/tasks/useTaskItem';
import moment from 'moment';
import IconXMark from '../icons/IconXMark.vue';
import CircleButton from './buttons/CircleButton.vue';
import type { TaskType } from '@/types/TaskType';
import { toValue } from 'vue';
import CheckBoxItem from './checkboxes/CheckBoxItem.vue';
import SkeletonLoading from '../loading/SkeletonLoading.vue';
import StatusPriorityItem from './StatusPriorityItem.vue';
import { PriorityTask, TaskStatus } from '@/enums/TaskEnum';
import { getDayDifferent } from '@/utils/tasks/date_helper';
import IconCheck from '../icons/IconCheck.vue';
import IconClock from '../icons/IconClock.vue';
import CheckBoxComplete from './checkboxes/CheckBoxComplete.vue';
import CheckBoxUncomplete from './checkboxes/CheckBoxUncomplete.vue';
const props = defineProps<{ task: TaskType }>();
const emit = defineEmits(['removeItem'])

const {
    mouseLeaveItem,
    mouseOverItem,
    removeItem,
    hoverItem, 
    loadingDelete,
    updateStatus,
    updateLoading,
    dayDiff,
    routeTo,
     } = useTaskItem(toValue(props.task));
</script>