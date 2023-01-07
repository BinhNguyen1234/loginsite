<script setup lang="ts">
import { ref,defineProps, type HTMLAttributes } from 'vue';
const getWidth = ()=>{
    return Math.random() * 4 + "px"
}
const getPosition = ()=>{
    return Math.random() * 100 + "%"
}
const getTop = ()=>{
    return Math.random() * 100 -50 + "%"
}
    const style  = ref({
        width: getWidth(),
        left: getPosition(),
        top: getPosition(),
       
    })
</script>
<template>
    <div v-bind:style="style" class="star"></div>
</template>
<style lang="sass" scoped>
@use "sass:math"
.star
    box-shadow: 0px 0px 9px white
    background-color: white
    aspect-ratio: 1/1
    border-radius: 50%
    position: absolute
</style>