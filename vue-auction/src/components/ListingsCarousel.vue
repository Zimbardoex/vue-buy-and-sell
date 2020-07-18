<template>
  <section>
    <b-carousel-list
      v-model="values"
      :data="listings"
      :arrow-hover="arrowHover"
      :items-to-list="perList"
      :has-drag="drag"
    >
      <template slot="item" slot-scope="props">
        <div class="card">
          <div class="card-image">
            <figure class="image is-5by4">
              <a @click="info(props.index)"><img :src="getImage(props.list.image)"/></a>
            </figure>
            <b-tag type="is-info" rounded style="position: absolute; top: 0;">
              <p class="control" style="margin-left: auto">
                {{ `$ ${props.list.price}` }}
              </p>
            </b-tag>
          </div>
          <div class="card-content">
            <div class="content">
              <p class="title is-6">{{ props.list.name }}</p>
              <p class="subtitle is-7">Caption will go here</p>
            </div>
          </div>
        </div>
      </template>
    </b-carousel-list>
  </section>
</template>

<script>
const API_URL = "http://localhost:5000/api";
import DefaultImage from "../assets/placeholder.jpg";

export default {
  name: "ListingsCarousel",
  data() {
    return {
      arrowHover: false,
      drag: true,
      values: 1,
      perList: 1,
      listings: [],
    };
  },
  mounted() {
    fetch(`${API_URL}/listings/random/?number=7`)
      .then((response) => response.json())
      .then((result) => {
        this.listings = result;
      });
  },
  methods: {
    getImage: function(image) {
      return image ? image : DefaultImage;
    },
  },
};
</script>
