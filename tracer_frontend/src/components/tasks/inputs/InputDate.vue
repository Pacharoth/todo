<template>
    <div class=" bg-white p-2 flex-col

    shadow-md
    space-y-2
    flex rounded-lg text-slate-600 font-semibold ">
        <div class="w-full font-bold">{{ title }}</div>
        <el-date-picker v-model="inputDate"
        :shortcuts="shortcuts" 
        type="datetime"
          placeholder="Pick a Date"
           format="YYYY-MM-DD h:m:s a" class="
         rounded-md outline-none 
        focus:outline-none" />
        <button @click="submit(true)"
            class="w-full bg-slate-500 transition-all flex justify-center text-white hover:bg-slate-600 px-4 py-1 rounded-md font-semibold">
            <template v-if="!loadingSaveStatus">
                Save
            </template>
            <template v-else>
                <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-white" />
            </template>
        </button>
        <button @click="submit(false)"
            class="w-full bg-gray-200 flex justify-center transition-all hover:bg-gray-300 px-4 py-1 rounded-md font-semibold">
            <template v-if="!loadingRemoveStatus
            ">
                Remove

            </template>
            <template v-else>
                <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-gray-400" />

            </template>
        </button>
    </div>

</template>
<script setup lang="ts">
import { ref, watch,onMounted } from 'vue';
import SkeletonLoading from '@/components/loading/SkeletonLoading.vue';
const inputDate = ref("")
const emit = defineEmits(['submit']);
const props = defineProps<{ 
    title: string, loadingSaveStatus: boolean,
     loadingRemoveStatus: boolean,
    inputValue?:Date }>();
function submit(status: boolean) {
    emit("submit", status ? inputDate.value : undefined);
}
onMounted(()=>{
    inputDate.value=props.inputValue??"";
})
const shortcuts = [
  {
    text: 'Today',
    value: new Date(),
  },
  {
    text: 'Yesterday',
    value: () => {
      const date = new Date()
      date.setDate(date.getDate() - 1)
      return date
    },
  },
  {
    text: 'A week ago',
    value: () => {
      const date = new Date()
      date.setDate(date.getDate() - 7)
      return date
    },
  },
]

</script>