<script setup lang="ts">
import Star from "./Star.vue"

</script>
<template>
    <div style="overflow: hidden; width: 100%; height: 100% ;position: absolute">
        <div v-for="(key, index) in 3 " v-bind:class="`Galaxy Galaxy-frame${index}`" >
            <Star v-for="(key,index) in 60" v-key="index"></Star>
        </div>
    </div>
</template>
<style lang="sass" scoped>
    .Galaxy
        opacity: 0
        z-index: 2
        position: absolute
        width: 100%
        height: 100%
    .Galaxy-frame0
        animation: Scale 15s ease-in infinite
    .Galaxy-frame1
        animation: Scale 15s ease-in 5s infinite
    .Galaxy-frame2
        animation: Scale 15s ease-in 10s infinite

</style>