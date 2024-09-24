<template>
    <div class="bg-white p-2 flex-col
    shadow-md
    space-y-2
    flex rounded-lg text-slate-600 font-semibold">
        <button 
        @click="click(index)"
        class="flex space-x-2 items-center bg-gray-100 hover:bg-gray-200  px-4 py-2 rounded-md"
        v-for=" (priorty,index) in priorityTask" :key="index" 
        :value="index">
            <template v-if="index==2">
                <div class="p-2 bg-slate-500 rounded-sm"></div>
            </template>
            <template v-else-if="index==1">
                <div class="p-2 bg-amber-400 rounded-sm"></div>
            </template>
            <template v-else-if="index==0">
                <div class="p-2 bg-rose-400 rounded-sm"></div>
            </template>
           <span class="capitalize">{{priorty}}</span>
        </button>
        <template v-if="loading">
            <div class="flex justify-center w-full">
                <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-gray-400" />
            </div>
        </template>
    </div>
</template>
<script setup lang="ts">
import { PriorityTask,PriorityTaskConstant,priorityTask,TaskStatusConstant } from '@/enums/TaskEnum';
import SkeletonLoading from '@/components/loading/SkeletonLoading.vue';

import {ref} from 'vue';
defineProps<{loading:boolean}>();
const emit =defineEmits(['click'])
function click(e){
    emit("click",e);
}
</script>