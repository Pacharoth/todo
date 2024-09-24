<template>
    <div @click="click"  class="bg-gray-100 flex
         items-center text-rose-400 px-2 
          w-full
          space-x-4
         justify-between
         py-2
          z-10 
         shadow-md rounded-md cursor-pointer">
           <div class="flex items-center space-x-2">
            <IconExclaimationTriangle className="w-5 h-5 animate-bounce " :strokeWidth="2"/>
                <p class="font-semibold">{{message}}</p>         
           </div> 
    </div>
</template>
<script setup lang="ts">
import IconExclaimationTriangle from '../icons/IconExclaimationTriangle.vue';
defineProps<{message?:string}>()
const emit = defineEmits(["click"]);
function click(){
    emit("click");
}
</script>