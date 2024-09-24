<template>
    <div class="flex flex-col ">
        <div v-if="!statusInput&&inputValue!=''" @click="click" class=" 
        py-1 cursor-pointer font-sans font-bold text-slate-700 text-lg">
            {{ inputValue }}
        </div>
        <div v-else-if="!statusInput&&inputValue==''" @click="click" class="
            bg-gray-200 hover:bg-gray-300 text-slate-600 w-full h-20 font-semibold
            cursor-pointer
            transition-all
            rounded-md
            p-4
        ">
            Add a description
        </div>
        <template v-else>
            <textarea  name="" class=" bg-gray-200
    font-sans
     font-bold resize-none rounded-md 
      transition-all
     text-slate-700
      outline-none
     selection:bg-slate-600
     selection:text-white
     focus:shadow-md 
     w-full
     text-lg
     focus:bg-gray-200
     placeholder:text-lg
      placeholder:bg-gray-200
       placeholder:rounded-md
      p-2" :value="inputValue"  @input="onchange"
      >
        </textarea>
       <div class="flex space-x-2 mt-2">
        <button @click="close" class="bg-gray-200 transition-all hover:bg-gray-300 px-4 py-2 rounded-md font-semibold">
            Cancel
        </button>
        <button @click="onSubmit" class="bg-slate-500 transition-all text-white hover:bg-slate-600 px-4 py-2 rounded-md font-semibold">
            <template v-if="loading">
                <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-white" />
            </template>
            <template v-else>
                Save
            </template>
        </button>
       </div>
        </template>
    
    </div>
</template>
<script setup lang="ts">
import SkeletonLoading from '@/components/loading/SkeletonLoading.vue';

defineProps<{
    inputValue?: string,
    statusInput: boolean,
    loading:boolean
}>();
const emit = defineEmits(['click', 'change',"submit","close"]);
function click() {
    emit("click")
}
function onSubmit(e:Event){
    emit("submit");
}
function onchange(e: Event) {
    emit("change", (e.currentTarget as HTMLInputElement).value);
}
function close(e:Event){
    emit("close");
}
</script>