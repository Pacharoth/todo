<template>

<svg :class="className" data-slot="icon" fill="none" :stroke-width="strokeWidth" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
  <path stroke-linecap="round" stroke-linejoin="round" d="M12 6v6h4.5m4.5 0a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"></path>
</svg>
</template>
<script setup lang="ts">
import type { IconType } from '../../types/IconType';

defineProps<IconType>();
</script>