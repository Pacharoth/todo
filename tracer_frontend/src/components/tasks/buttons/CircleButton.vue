<template>
    <button @click="emitAction" :disabled="disabled" :class="`
      text-slate-800  rounded-full text p-2
      flex justify-center items-center
      ${disabled ? 'bg-gray-100' :
          'hover:scale-110 bg-white hover:bg-gray-100'} transition-all`">
       <slot></slot>
    </button>
 </template>
 <script setup lang="ts">
 defineProps<{ disabled: boolean }>()
 const emit = defineEmits(['click']);
 function emitAction(){
   emit("click");
 }
 </script>