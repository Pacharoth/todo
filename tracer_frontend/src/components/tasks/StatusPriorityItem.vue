<template>
    <div :class="`  rounded-t-md  py-5 w-full ${className}`">
    </div>
</template>
<script setup lang="ts">
defineProps<{className?:string}>()
</script>