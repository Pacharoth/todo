<template>
    <div class="text-slate-600">
        <div v-if="!statusInput" @click="click" class=" 
        py-1 cursor-text font-sans font-bold text-2xl">
            {{ inputValue }}
        </div>
        <input v-else class="  bg-gray-200
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
      p-2" :value="inputValue" @input="onchange"
      @change="onSubmit" />
    </div>
</template>
<script setup lang="ts">
defineProps<{
    inputValue?: string,
    statusInput: boolean
}>();
const emit = defineEmits(['click', 'change',"submit"]);
function click() {
    emit("click")
}
function onSubmit(e:Event){
    emit("submit",(e.currentTarget as HTMLInputElement).value);
}
function onchange(e: Event) {
    emit("change", (e.currentTarget as HTMLInputElement).value);
}
</script>