<template>
    <div :class="`${className} w-10 h-10  rounded-full`">
    </div>
</template>
<script setup lang="ts">
defineProps<{ className: string }>()
</script>