<template>
    <div class=" text-slate-700 flex justify-center  space-x-2 items-center">
        <IconBox :stroke-width="2" className=" w-5 h-5 transition-all hover:scale-110 "/>
        <p class="font-semibold">{{ localization.en.noItem }}</p>
    </div>
</template>
<script setup lang="ts">
import { localization } from '@/localization';
import IconBox from '../icons/IconBox.vue';
</script>