<template>
    <CheckBoxItem @update="updateStatus(true)" :className="`group text-white ${className}`">
        <template v-if="loading">
            <SkeletonLoading className="h-5 w-5 [&>*]:w-20 text-white [&>*]:bg-white" />
        </template>
        <template v-else>
            <div class="hidden group-hover:block group-hover:animate-fade w-4 h-4 border-white rounded-md border-2">
            </div>
        </template>
        <IconClock className="w-5 h-5 group-hover:hidden group-hover :animate-fade " :stroke-width="2" />
        <p v-if="dueTo">{{ dueTo }}</p>
        

    </CheckBoxItem>
</template>
<script setup lang="ts">
import moment from 'moment';
import CheckBoxItem from './CheckBoxItem.vue';
import type { TaskType } from '@/types/TaskType';
import IconClock from '../../icons/IconClock.vue';
import SkeletonLoading from '@/components/loading/SkeletonLoading.vue';
import { onMounted,ref,toValue } from 'vue';
const dueTo = ref();
const props =defineProps<{ task: TaskType, className?: string,loading:boolean }>();
const emit = defineEmits(['update'])
onMounted(()=>{
   dueTo.value= props.task?.dueTo ? moment(props.task.dueTo).format('LL') : undefined; 
})
function updateStatus(status: boolean) {
    emit("update", status)
}
</script>