<template>
    <svg :class="className" data-slot="icon" fill="none" :stroke-width="strokeWidth" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
  <path stroke-linecap="round" stroke-linejoin="round" d="M6 18 18 6M6 6l12 12"></path>
</svg>
</template>
<script setup lang="ts">
import type { IconType } from '@/types/IconType';

defineProps<IconType>();
</script>