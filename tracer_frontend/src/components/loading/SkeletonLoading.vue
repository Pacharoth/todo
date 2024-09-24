<template>
    <div :class="`spinner ${className} flex space-x-1`">
      <div class="rect1"></div>
      <div class="rect2"></div>
      <div class="rect3"></div>
    </div>
</template>
<style scoped>
@import url('../../assets/loading_sk.css');
</style>
<script setup lang="ts">
  defineProps<{className?:string}>();
</script>