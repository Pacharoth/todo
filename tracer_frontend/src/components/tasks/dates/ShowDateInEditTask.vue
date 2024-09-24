<template>
    <div v-if="inputDate" class="flex  text-slate-600 items-center py-2 px-1 ">
        <div class="flex bg-gray-200 items-center px-2 py-2 rounded-md space-x-2">
            <IconClock className="w-5 h-5 " :strokeWidth="2" /> <span class="font-semibold">{{
                moment(inputDate).calendar() }}</span>
            <template v-if="statusTask == TaskStatus.COMPLETE">
                <div class="bg-lime-700 animate-fade text-white text-xs font-semibold px-2 py-1 rounded-md ">
                    Complete
                </div>
            </template>
            <template v-else-if="diffDate <0">
                <div class="bg-rose-600 animate-fade text-white text-xs font-semibold px-2 py-1 rounded-md ">
                    Overdue
                </div>
            </template>
            <template v-else-if="diffDate <5">
                <div class="bg-amber-600 animate-fade text-white text-xs font-semibold px-2 py-1 rounded-md ">
                    Due Soon
                </div>
            </template>
        </div>

    </div>
</template>
<script setup lang="ts">
import moment from 'moment';
import { computed } from 'vue'
import { TaskStatus, } from "@/enums/TaskEnum"
import {getDayDifferent} from '@/utils/tasks/date_helper'
const props =defineProps<{ inputDate?: Date, statusTask: TaskStatus }>();
const diffDate =computed(()=>props?.inputDate?getDayDifferent(props?.inputDate):undefined)

</script>