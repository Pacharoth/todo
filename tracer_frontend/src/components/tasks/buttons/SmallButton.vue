<template>
   <button
   :disabled="disabled" :class="`px-4 py-2
     text-white rounded-md text
     animate-fade
     flex justify-center
     ${disabled ? 'bg-slate-400' :
         'hover:scale-110 hover:shadow-md bg-slate-700 hover:bg-slate-600'} transition-all`">
      <slot></slot>
   </button>
</template>
<script setup lang="ts">
defineProps<{ disabled: boolean }>();

</script>