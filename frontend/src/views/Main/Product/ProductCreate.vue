<template>
  <showcase-create ref="form" v-bind="createData" @onSend="createCategory($event)"/>
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import {
  required,
  numeric
} from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'ProductCreate',
  components: {
    ShowcaseCreate
  },
  setup () {
    const toast = useToast()
    return { toast }
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
            label: 'Категория',
            placeholder: 'Категория',
            modelValue: 'categoryId',
            type: 'select',
            values: [],
            validation: { required }
          },
          {
            label: 'Вид упаковки',
            placeholder: 'Вид упаковки',
            modelValue: 'packageType',
            type: 'select',
            values: [
              {
                text: 'Потребительская',
                value: 0
              },
              {
                text: 'Транспортная',
                value: 1
              },
              {
                text: 'Производственная',
                value: 2
              },
              {
                text: 'Консервирующая',
                value: 3
              }
            ],
            validation: { required }
          },
          {
            label: 'Кол-во в упаковке',
            placeholder: 'Кол-во в упаковке',
            modelValue: 'packageNumber',
            type: 'number',
            cols: ['col-md-3'],
            validation: { required, numeric }
          },
          {
            label: 'Кол-во на складе',
            placeholder: 'Кол-во',
            modelValue: 'quantity',
            type: 'number',
            cols: ['col-md-3'],
            validation: { required, numeric }
          },
          {
            label: 'Цена за единицу',
            placeholder: 'Цена, ₽',
            modelValue: 'price',
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Минимальный заказ',
            placeholder: 'Мин заказ, шт.',
            modelValue: 'minimalOrder',
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Вес',
            placeholder: 'Вес, кг',
            modelValue: 'weight',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Высота',
            placeholder: 'Высота, см',
            modelValue: 'height',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Ширина',
            placeholder: 'Ширина, см',
            modelValue: 'width',
            cols: ['col-md-3'],
            type: 'number',
            validation: { required, numeric }
          },
          {
            label: 'Длина',
            placeholder: 'Длина, см',
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
    createCategory (data) {
      this.$api.product.createProduct(data)
        .then(() => {
          this.toast.success('Продукт успешно создан')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании продукта, повторите позже')
        })
    }
  },
  created () {
    this.$api.category.getParentsCategory()
      .then(data => {
        this.createData.fields.find(item => item.modelValue === 'categoryId').values = data.map(item => {
          return Object.assign({}, { text: item.name, value: item.id })
        })
      })
  }
}
</script>
