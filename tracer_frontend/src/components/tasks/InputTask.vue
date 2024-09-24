<template>
    <!-- Task Input -->
    <div class="relative">
        <textarea @contextmenu="contextmenu" :required="required" class="
     bg-gray-200
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
      p-2 " :value="inputValue" @input="onChange" :placeholder="placeHolder" :rows="numRow">
     </textarea>
     
     <div class="animate-fade pl-2">
        <template v-if="error&&error!=''">
            <p class="text-rose-400">
                <slot name="error"></slot>
            </p>
        </template>
     </div>
    </div>
</template>
<script setup lang="ts">

defineProps<{
    placeHolder?: string,
    inputValue?: string,
    required?: boolean,
    numRow?: number,
    error?:string,
    contextmenu?: ((payload: MouseEvent) => void) | undefined
}>();
const emit = defineEmits(['inputChange'])
function onChange(e: any) {
    emit("inputChange", e.target?.value);
}
</script>
