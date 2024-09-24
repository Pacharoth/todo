<template>
    <div class="bg-white h-screen w-screen flex items-center justify-center">
        <div class="relative flex items-center flex-col p-2 z-10">
            <CircleBackground className=" bg-slate-600/50 absolute left-2 blur-sm"/>
            <CircleBackground className=" bg-slate-400/50 absolute right-2 blur-sm"/>
            <CircleBackground className=" bg-red-400 absolute bottom-2 blur-md"/>
            <CircleBackground className=" bg-yellow-200 absolute bottom-5 right-4 blur-md"/>
            <h1 class=" animate-bounce drop-shadow-md font-bold text-8xl text-gray-600">404</h1>
            <p class="font-semibold text-2xl text-gray-700 drop-shadow-md">Page Not Found</p>
        </div>
    </div>
</template>
<script setup lang="ts">
import CircleBackground from '@/components/404/CircleBackground.vue';
</script>