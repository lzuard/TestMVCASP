<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Артикул">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.art"
        placeholder="Артикул"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Прозиводитель">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.manufacture"
        placeholder="Прозиводитель"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Наименование">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.name"
        placeholder="Наименование"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Тип товара">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.type"
        placeholder="Тип товара"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Категория">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.category"
        placeholder="Категория"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Подкатегория">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.subcategory"
        placeholder="Подкатегория"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Вид упаковки">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.packageType"
        placeholder="Вид упаковки"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Кол-во в упаковке">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.packageNum"
        placeholder="Кол-во"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Кол-во на складе">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.stockNum"
        placeholder="Кол-во"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Цена за единицу">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.pricePerUnit"
        placeholder="Цена"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Минимальный заказ">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.minOrder"
        placeholder="Мин заказ"
      >
    </showcase-label>

    <showcase-label class="col-md-3" label="Вес">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.weight"
        placeholder="Вес"
      >
    </showcase-label>

    <showcase-label class="col-md-3" label="Высота">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.height"
        placeholder="Высота"
      >
    </showcase-label>

    <showcase-label class="col-md-3" label="Ширина">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.width"
        placeholder="Ширина"
      >
    </showcase-label>

    <showcase-label class="col-md-3" label="Длина">
      <input
        class="form-control"
        type="number"
        v-model="dataToSend.length"
        placeholder="Длина"
      >
    </showcase-label>

    <showcase-label class="col-md-12" label="Описание">
      <textarea
        class="form-control"
        v-model="dataToSend.description"
      ></textarea>
    </showcase-label>

    <showcase-label class="col-md-12" label="Уценен">
      <input
        class="form-check-input"
        type="checkbox"
        v-model="dataToSend.isDiscount"
      >
    </showcase-label>

    <showcase-label class="col-md-12" label="Причина">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.reason"
        placeholder="Причина уценки"
      >
    </showcase-label>

    <showcase-errors-list
      v-if="v$.$errors.length"
      :errors="v$.$errors"
    />

    <showcase-submit @click="sendToServer">
      <edit-icon />
      Создать
    </showcase-submit>
  </showcase-create>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import ShowcaseErrorsList from '@/components/Showcase/showcase-errors-list'
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import ShowcaseLabel from '@/components/Showcase/showcase-label-field'
import ShowcaseSubmit from '@/components/Showcase/showcase-submit-button'
import { EditIcon } from '@iconicicons/vue3'
import {
  required
} from '@/utils/validation/i18n-validators'

export default {
  name: 'ProductCreate',
  components: {
    ShowcaseCreate,
    ShowcaseLabel,
    ShowcaseSubmit,
    ShowcaseErrorsList,
    EditIcon
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      dataToSend: {
        art: { required },
        manufacture: { required },
        name: { required },
        type: { required },
        category: { required },
        subcategory: { required },
        packageType: { required },
        packageNum: { required },
        stockNum: { required },
        pricePerUnit: { required },
        minOrder: { required },
        weight: { required },
        height: { required },
        width: { required },
        length: { required },
        description: { required }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать товар'
      },
      dataToSend: {
        art: '',
        manufacture: '',
        name: '',
        type: '',
        category: '',
        subcategory: '',
        packageType: '',
        packageNum: '',
        stockNum: '',
        pricePerUnit: '',
        minOrder: '',
        weight: '',
        height: '',
        width: '',
        length: '',
        description: '',
        isDiscount: false,
        reason: ''
      }
    }
  },
  methods: {
    async sendToServer () {
      const isReady = await this.v$.$validate()

      if (!isReady) {
        console.log('Ошибка!')
      } else {
        console.log('Объект готов к отправке', this.dataToSend)
      }
    }
  }
}
</script>
