<template>
  <showcase-create v-bind="createData" @onSend="sendToServer($event)"/>
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import {
  required,
  numeric
} from '@/utils/validation/i18n-validators'

export default {
  name: 'ProductCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать товар',
        fields: [
          {
            label: 'Артикул',
            placeholder: 'Артикул',
            modelValue: 'art',
            validation: { required }
          },
          {
            label: 'Производитель',
            placeholder: 'Производитель',
            modelValue: 'manufacture',
            validation: { required }
          },
          {
            label: 'Наименование',
            placeholder: 'Наименование',
            modelValue: 'name',
            validation: { required }
          },
          {
            label: 'Тип товара',
            placeholder: 'Тип товара',
            modelValue: 'type',
            validation: { required }
          },
          {
            label: 'Категория',
            placeholder: 'Категория',
            modelValue: 'category',
            validation: { required }
          },
          {
            label: 'Подкатегория',
            placeholder: 'Подкатегория',
            modelValue: 'subcategory',
            validation: { required }
          },
          {
            label: 'Вид упаковки',
            placeholder: 'Вид упаковки',
            modelValue: 'packageType',
            validation: { required }
          },
          {
            label: 'Кол-во в упаковке',
            placeholder: 'Кол-во в упаковке',
            modelValue: 'packageNum',
            type: 'number',
            cols: ['col-md-3'],
            validation: { required, numeric }
          },
          {
            label: 'Кол-во на складе',
            placeholder: 'Кол-во',
            modelValue: 'stockNum',
            type: 'number',
            cols: ['col-md-3'],
            validation: { required, numeric }
          },
          {
            label: 'Цена за единицу',
            placeholder: 'Цена',
            modelValue: 'pricePerUnit',
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Минимальный заказ',
            placeholder: 'Мин заказ',
            modelValue: 'minOrder',
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Вес',
            placeholder: 'Вес',
            modelValue: 'weight',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Высота',
            placeholder: 'Высота',
            modelValue: 'height',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Ширина',
            placeholder: 'Ширина',
            modelValue: 'width',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Длина',
            placeholder: 'Длина',
            modelValue: 'length',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Описание',
            placeholder: 'Описание',
            modelValue: 'description',
            cols: ['col-md-12'],
            type: 'textarea',
            validation: { required }
          },
          {
            label: 'Уценен',
            modelValue: 'isDiscount',
            cols: ['col-auto'],
            type: 'checkbox'
          },
          {
            label: 'Причина',
            placeholder: 'Причина',
            cols: ['col-md-4'],
            modelValue: 'reason'
          }
        ]
      }
    }
  },
  methods: {
    sendToServer (data) {
      console.log(data)
    }
  }
}
</script>
