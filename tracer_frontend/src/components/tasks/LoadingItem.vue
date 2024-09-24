<template>
    <div class="flex justify-center">
        <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-gray-400" />
    </div>
</template>
<script setup lang="ts">
import SkeletonLoading from '../loading/SkeletonLoading.vue';
</script>