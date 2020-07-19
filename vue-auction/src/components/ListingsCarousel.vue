<template>
  <section>
    <b-carousel-list
      v-model="values"
      :data="listings"
      :arrow-hover="arrowHover"
      :items-to-list="perList"
      :has-drag="drag"
      v-if="listings"
    >
      <template slot="item" slot-scope="props">
        <div class="card">
          <div class="card-image">
            <figure class="image is-5by4">
              <a @click="info(props.list.id)"
                ><img :src="getImage(props.list.image)"
              /></a>
            </figure>
            <b-tag type="is-info" rounded style="position: absolute; top: 0;">
              <p class="control" style="margin-left: auto">
                {{ `$ ${props.list.price}` }}
              </p>
            </b-tag>
          </div>
          <div class="card-content">
            <div class="content">
              <p class="title is-6 listing-title">{{ props.list.name }}</p>
              <p class="subtitle is-7">Caption will go here</p>
            </div>
          </div>
        </div>
      </template>
    </b-carousel-list>
  </section>
</template>

<script>
import DefaultImage from "../assets/placeholder.jpg";

export default {
  name: "ListingsCarousel",
  data() {
    return {
      arrowHover: false,
      drag: true,
      values: 0,
    };
  },
  props:{
    listings: Array,
  },
  methods: {
    getImage: function(image) {
      return image ? image : DefaultImage;
    },
    info: function(listing_id) {
      const router = this.$router;
      router.push({ path: "listing", query: { id: listing_id } });
    },
  },
};
</script>

<style>
.listing-title {
  white-space: nowrap;
  text-overflow: ellipsis;
  overflow: hidden;
}
</style>
