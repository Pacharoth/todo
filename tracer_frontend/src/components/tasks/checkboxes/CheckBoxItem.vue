<template>
    <button 
    :class="` animate-fade flex space-x-1 text-sm items-center rounded-md ${className}`"
    @click="update"
    >
         <slot></slot>
    </button>
</template>
<script setup lang="ts">
defineProps<{className?:string}>();
const emit=defineEmits(["update"]);
function update(){
    emit("update");
}
</script>