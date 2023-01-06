<script setup lang="ts">
import Star from "./Star.vue"

</script>
<template>
    <div style="overflow: hidden; width: 100%; height: 100% ;position: absolute">
        <div v-for="(key, index) in 7" v-bind:class="`Galaxy Galaxy-frame${index}`" >
            <Star v-for="(key,index) in 20" v-key="index"></Star>
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
        animation: Scale 12s infinite
    .Galaxy-frame1
        animation: Scale 12s 2s infinite
    .Galaxy-frame2
        animation: Scale 12s 4s infinite
    .Galaxy-frame3
        animation: Scale 12s 6s infinite
    .Galaxy-frame4
        animation: Scale 12s 8s infinite
    .Galaxy-frame5
        animation: Scale 12s 10s infinite
    .Galaxy-frame6
        animation: Scale 12s 12s infinite
</style>