<template>
    <div class=" text-rose-400 flex justify-center  space-x-2 items-center">
        <IconExclaimationTriangle :stroke-width="2" className=" w-5 h-5 transition-all hover:scale-110 "/>
        <p class="font-semibold">
            <slot></slot>
        </p>
    </div>
</template>
<script setup lang="ts">
import IconExclaimationTriangle from '../icons/IconExclaimationTriangle.vue';
</script>