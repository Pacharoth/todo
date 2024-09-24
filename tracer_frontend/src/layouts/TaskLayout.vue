<template>
    <section class="relative flex items-center w-screen h-screen justify-center overflow-x-hidden selection:text-white
     selection:bg-slate-500 selection:p-2 selection:rounded-md">
        <slot></slot>
        <RouterView/>
        <AlertStatus/>
    </section>
</template>
<script setup lang="ts">
import { RouterView } from 'vue-router';
import AlertStatus from '@/components/AlertStatus.vue';
</script>